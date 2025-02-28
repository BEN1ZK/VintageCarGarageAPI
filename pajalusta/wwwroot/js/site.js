document.addEventListener("DOMContentLoaded", function () {
    const signupForm = document.getElementById('signupForm');

    if (signupForm) {
        signupForm.addEventListener('submit', async (e) => {
            e.preventDefault();

            const name = document.getElementById('signupName').value;
            const email = document.getElementById('signupEmail').value;
            const password = document.getElementById('signupPassword').value;
            const repeatPassword = document.getElementById('signupRepeatPassword').value;
            const phone = document.getElementById('signupPhone').value;

            // ✅ Ensure the RepeatPassword field is included
            if (!repeatPassword) {
                alert('Repeat password is required.');
                return;
            }

            if (password !== repeatPassword) {
                alert('Passwords do not match.');
                return;
            }

            // ✅ Make sure the field name matches what your API expects (`repeatPassword`)
            const user = {
                name: name,
                email: email,
                password: password,
                repeatPassword: repeatPassword, // ✅ Ensure this field is included
                phone: phone,
                role: "user"
            };

            console.log("🟢 Sending Payload:", JSON.stringify(user, null, 2)); // Debugging

            try {
                const response = await fetch('http://localhost:5088/api/users/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(user),
                });

                const data = await response.json();
                console.log("🔴 API Response:", data); // Debugging

                if (response.ok) {
                    alert('Registration successful!');
                    window.location.href = '/login.html'; // Redirect to login page
                } else {
                    alert(data.message || 'Registration failed.');
                }
            } catch (error) {
                console.error("🚨 Error during registration:", error);
                alert('An error occurred while signing up.');
            }
        });
    }
});
