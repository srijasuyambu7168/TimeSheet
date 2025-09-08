const API_URL = "https://localhost:7077/api"; // ✅ Correct port
let loggedInEmployee = null;

// Login
document.getElementById("loginForm")?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const email = document.getElementById("loginEmail").value;
    const password = document.getElementById("loginPassword").value;

    const res = await fetch(`${API_URL}/employee/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password })
    });

    if (res.ok) {
        loggedInEmployee = await res.json();
        localStorage.setItem("employee", JSON.stringify(loggedInEmployee));
        window.location.href = "timesheet.html"; // redirect
    } else {
        alert("Invalid login");
    }
});

// Register
document.getElementById("registerForm")?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const name = document.getElementById("regName").value;
    const email = document.getElementById("regEmail").value;
    const password = document.getElementById("regPassword").value;

    const res = await fetch(`${API_URL}/employee/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name, email, password })
    });

    if (res.ok) {
        alert("Registered successfully! Now login.");
        window.location.href = "login.html"; // go to login page
    } else {
        alert("Email already exists.");
    }
});

// Timesheet
document.getElementById("timesheetForm")?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const employee = JSON.parse(localStorage.getItem("employee"));
    if (!employee) {
        alert("You must be logged in first.");
        return;
    }

    const date = document.getElementById("date").value;
    const hours = document.getElementById("hours").value;
    const task = document.getElementById("task").value;

    const res = await fetch(`${API_URL}/timesheet`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            employeeId: employee.employeeId,
            date,
            hoursWorked: hours,
            taskDescription: task
        })
    });

    if (res.ok) {
        loadTimesheets();
        document.getElementById("timesheetForm").reset();
    } else {
        alert("Error adding timesheet");
    }
});

// Load Timesheets
async function loadTimesheets() {
    const employee = JSON.parse(localStorage.getItem("employee"));
    if (!employee) return;

    const res = await fetch(`${API_URL}/timesheet/employee/${employee.employeeId}`);
    const data = await res.json();

    const tbody = document.querySelector("#timesheetTable tbody");
    tbody.innerHTML = "";
    data.forEach(ts => {
        tbody.innerHTML += `
      <tr>
        <td>${ts.date}</td>
        <td>${ts.hoursWorked}</td>
        <td>${ts.taskDescription}</td>
        <td>
          <button class="btn btn-danger btn-sm" onclick="deleteTimesheet(${ts.id})">Delete</button>
        </td>
      </tr>`;
    });
}

// Delete Timesheet
async function deleteTimesheet(id) {
    await fetch(`${API_URL}/timesheet/${id}`, { method: "DELETE" });
    loadTimesheets();
}

if (window.location.pathname.includes("timesheet.html")) {
    loadTimesheets();
}
