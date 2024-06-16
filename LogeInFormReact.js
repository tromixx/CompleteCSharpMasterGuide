/*
Create a login form component in React.

It should consist of username and one for password. Each input should update its value attribute on input change. There should also be a Submit button that should call the onSubbmit handler when clicked.

The onSubmit handler is passed through the props to the component and accepts two parameters: username and password (in that order).

When the Submit button is clicked, onSubmit handler should be called. Use a button click event handler for this purpose.

The application uses React 16.13.1
*/

import React, { useState } from 'react';

const LoginForm = ({ onSubmit }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleUsernameChange = (event) => {
    setUsername(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault(); // Prevent default form submission
    if (username.trim() === '' || password.trim() === '') {
      return; // Do not submit if username or password is empty
    }
    onSubmit(username, password);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="username-input">Username:</label>
          <input
            type="text"
            id="username-input"
            value={username}
            onChange={handleUsernameChange}
          />
        </div>
        <div>
          <label htmlFor="password-input">Password:</label>
          <input
            type="password"
            id="password-input"
            value={password}
            onChange={handlePasswordChange}
          />
        </div>
        <button type="submit" id="login-button" disabled={!username || !password}>
          Submit
        </button>
      </form>
    </div>
  );
};

export default LoginForm;