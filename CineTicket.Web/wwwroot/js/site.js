// Movies Statuses
document.querySelectorAll('.status').forEach(function(status) {
    if (status.innerText == "Available") {
        status.classList.add("text-success");
    } else if (status.innerText == "Expired") {
        status.classList.add("text-danger");
    } else {
        status.classList.add("text-warning");
    }
});