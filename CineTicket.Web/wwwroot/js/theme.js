// Theme switcher functionality
document.addEventListener("DOMContentLoaded", function () {
  // Check for saved theme preference or use default (light)
  const currentTheme = localStorage.getItem("theme") || "light";

  // Apply the saved theme on page load
  if (currentTheme === "dark") {
    document.body.classList.add("dark-mode");
  }

  // Create theme toggle button if it doesn't exist
  if (!document.querySelector(".theme-toggle")) {
    const themeToggle = document.createElement("button");
    themeToggle.className = "theme-toggle";
    themeToggle.setAttribute("aria-label", "Toggle light/dark mode");
    themeToggle.innerHTML = `
            <i class="bi bi-sun"></i>
            <i class="bi bi-moon"></i>
        `;
    document.body.appendChild(themeToggle);

    // Toggle theme when button is clicked
    themeToggle.addEventListener("click", toggleTheme);
  } else {
    // If button already exists, just add the event listener
    document
      .querySelector(".theme-toggle")
      .addEventListener("click", toggleTheme);
  }

  // Function to toggle between dark and light themes
  function toggleTheme() {
    const button = document.querySelector(".theme-toggle");

    // Add animation class
    button.classList.add("animate-toggle");

    if (document.body.classList.contains("dark-mode")) {
      // Switch to light mode
      document.body.classList.remove("dark-mode");
      localStorage.setItem("theme", "light");
    } else {
      // Switch to dark mode
      document.body.classList.add("dark-mode");
      localStorage.setItem("theme", "dark");
    }

    // Remove animation class after animation completes
    setTimeout(() => {
      button.classList.remove("animate-toggle");
    }, 300);
  }

  // Add animation styles
  const style = document.createElement("style");
  style.textContent = `
    .theme-toggle {
      transition: transform 0.3s cubic-bezier(0.34, 1.56, 0.64, 1);
    }
    .animate-toggle {
      transform: rotate(180deg);
    }
  `;
  document.head.appendChild(style);
});
