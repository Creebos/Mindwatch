export const authService = {
  // Simulated login function
  login(username, password) {
    // Simulated users with roles
    const users = {
      employee: { role: "Employee", name: "John Doe" },
      hr: { role: "HRManager", name: "Jane Doe" },
      manager: { role: "Manager", name: "Boss" },
    };

    // Check credentials
    const user = users[username.toLowerCase()];
    if (user && password === "password") {
      return user; // Return the matched user
    } else {
      throw new Error("Invalid credentials"); // Handle incorrect login
    }
  },
};
