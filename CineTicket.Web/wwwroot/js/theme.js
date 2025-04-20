// Theme switcher functionality
document.addEventListener("DOMContentLoaded", () => {
  const THEME_STORAGE_KEY = "theme";
  const DARK_MODE_CLASS = "dark-mode";
  const ANIMATION_DURATION = 300; // milliseconds
  
  // Check for saved theme preference or use default (light)
  const currentTheme = localStorage.getItem(THEME_STORAGE_KEY) || "light";
  
  // Apply the saved theme on page load
  if (currentTheme === "dark") {
    document.body.classList.add(DARK_MODE_CLASS);
  }
  
  // Function to toggle between dark and light themes
  const toggleTheme = () => {
    const button = document.querySelector(".theme-toggle");
    
    // Add animation class
    button.classList.add("animate-toggle");
    
    const isDarkMode = document.body.classList.contains(DARK_MODE_CLASS);
    const newTheme = isDarkMode ? "light" : "dark";
    
    // Toggle dark mode class
    document.body.classList.toggle(DARK_MODE_CLASS);
    
    // Save preference to localStorage
    localStorage.setItem(THEME_STORAGE_KEY, newTheme);
    
    // Remove animation class after animation completes
    setTimeout(() => {
      button.classList.remove("animate-toggle");
    }, ANIMATION_DURATION);
  };
  
  // Initialize theme toggle button
  const initThemeToggle = () => {
    // Create theme toggle button if it doesn't exist
    let themeToggle = document.querySelector(".theme-toggle");
    
    if (!themeToggle) {
      themeToggle = document.createElement("button");
      themeToggle.className = "theme-toggle";
      themeToggle.setAttribute("aria-label", "Toggle light/dark mode");
      themeToggle.innerHTML = `
        <i class="bi bi-sun"></i>
        <i class="bi bi-moon"></i>
      `;
      document.body.appendChild(themeToggle);
    }
    
    // Add event listener
    themeToggle.addEventListener("click", toggleTheme);
    
    // Add animation styles if not already present
    if (!document.getElementById("theme-toggle-styles")) {
      const style = document.createElement("style");
      style.id = "theme-toggle-styles";
      style.textContent = `
        .theme-toggle {
          transition: transform ${ANIMATION_DURATION}ms cubic-bezier(0.34, 1.56, 0.64, 1);
        }
        .animate-toggle {
          transform: rotate(180deg);
        }
      `;
      document.head.appendChild(style);
    }
  };
  
  // Initialize the theme toggle
  initThemeToggle();
});
