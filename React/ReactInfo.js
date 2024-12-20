// React Interview Guide - Code Examples

// Example: Functional Component
function Greeting({ name }) {
  return <h1>Hello, {name}!</h1>;
}

// Example: Class Component
class GreetingClass extends React.Component {
  render() {
    return <h1>Hello, {this.props.name}!</h1>;
  }
}

// Example: State Management with useState
import React, { useState } from 'react';
function Counter() {
  const [count, setCount] = useState(0);
  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}

// Example: Side Effects with useEffect
import React, { useEffect } from 'react';
function DataFetcher() {
  useEffect(() => {
    fetch('/api/data')
      .then((response) => response.json())
      .then((data) => console.log(data));
  }, []); // Empty array ensures effect runs once

  return <div>Data fetching in progress...</div>;
}

// Example: Higher-Order Component
function withLogging(WrappedComponent) {
  return function EnhancedComponent(props) {
    console.log('Rendering Component');
    return <WrappedComponent {...props} />;
  };
}

// Example: React Portals
import ReactDOM from 'react-dom';
function Modal({ children }) {
  return ReactDOM.createPortal(
    <div className="modal">{children}</div>,
    document.getElementById('portal-root')
  );
}

// Example: Error Boundary
class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false };
  }

  static getDerivedStateFromError() {
    return { hasError: true };
  }

  componentDidCatch(error, info) {
    console.error('Error caught:', error, info);
  }

  render() {
    if (this.state.hasError) {
      return <h1>Something went wrong.</h1>;
    }
    return this.props.children;
  }
}

// Example: Memoization with React.memo
const MemoizedComponent = React.memo(function MyComponent({ value }) {
  return <div>{value}</div>;
});

// Example: Context API
const ThemeContext = React.createContext('light');
function ThemeProvider({ children }) {
  const [theme, setTheme] = useState('light');
  return (
    <ThemeContext.Provider value={{ theme, setTheme }}>
      {children}
    </ThemeContext.Provider>
  );
}
function ThemedButton() {
  const { theme } = React.useContext(ThemeContext);
  return <button className={theme}>Themed Button</button>;
}

// Example: Controlled Component
function ControlledInput() {
  const [value, setValue] = useState('');
  return (
    <input value={value} onChange={(e) => setValue(e.target.value)} />
  );
}

// Example: Uncontrolled Component
function UncontrolledInput() {
  const inputRef = React.useRef(null);
  const handleClick = () => {
    console.log(inputRef.current.value);
  };
  return (
    <div>
      <input ref={inputRef} />
      <button onClick={handleClick}>Log Value</button>
    </div>
  );
}


// Exercises
/*
1. Build a Counter Component
Objective: Create a simple counter that can increment and decrement.
Requirements:
Use state (useState) to track the count.
Two buttons: "Increment" and "Decrement."
Prevent the counter from going below zero.
*/
import React, { useState } from "react";

function Counter() {
  const [count, setCount] = useState(0);

  return (
    <div>
      <h1>Counter: {count}</h1>
      <button onClick={() => setCount(count + 1)}>Increment</button>
      <button onClick={() => setCount(count > 0 ? count - 1 : 0)}>Decrement</button>
    </div>
  );
}

export default Counter;

/*
2. Render a List
Objective: Display a list of items from an array.
Requirements:
Use the map function to render a list of strings as <li> elements.
Add a "Remove" button next to each item to remove it from the list.
*/
import React, { useState } from "react";

function RenderList() {
  const [items, setItems] = useState(["Item 1", "Item 2", "Item 3"]);

  const handleRemove = (index) => {
    setItems(items.filter((_, i) => i !== index));
  };

  return (
    <div>
      <ul>
        {items.map((item, index) => (
          <li key={index}>
            {item}
            <button onClick={() => handleRemove(index)}>Remove</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default RenderList;

/*
3. Controlled Input
Objective: Build a form with a text input field.
Requirements:
Use state to control the input value.
Display the entered value in real-time below the input field.
Add a "Clear" button to reset the input.
Intermediate Level
*/
import React, { useState } from "react";

function ControlledInput() {
  const [value, setValue] = useState("");

  return (
    <div>
      <input
        type="text"
        value={value}
        onChange={(e) => setValue(e.target.value)}
      />
      <button onClick={() => setValue("")}>Clear</button>
      <p>Current Value: {value}</p>
    </div>
  );
}

export default ControlledInput;

/*
4. Fetch and Display Data
Objective: Fetch data from an API and display it.
Requirements:
Use useEffect to fetch data when the component mounts.
Display a loading indicator while fetching.
Render the data in a list format.
Handle and display errors.
*/
import React, { useState, useEffect } from "react";

function FetchData() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("https://jsonplaceholder.typicode.com/posts")
      .then((response) => response.json())
      .then((data) => {
        setData(data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <ul>
      {data.slice(0, 10).map((post) => (
        <li key={post.id}>{post.title}</li>
      ))}
    </ul>
  );
}

export default FetchData;

/*
5. Tab Component
Objective: Create a reusable tab component.
Requirements:
Render multiple tabs with headers.
Clicking on a tab displays its content.
The active tab should have a distinct style.
*/
import React, { useState } from "react";

function Tabs() {
  const [activeTab, setActiveTab] = useState(0);
  const tabs = [
    { title: "Tab 1", content: "Content for Tab 1" },
    { title: "Tab 2", content: "Content for Tab 2" },
    { title: "Tab 3", content: "Content for Tab 3" },
  ];

  return (
    <div>
      <div style={{ display: "flex", cursor: "pointer" }}>
        {tabs.map((tab, index) => (
          <div
            key={index}
            style={{
              padding: "10px 20px",
              borderBottom: activeTab === index ? "2px solid blue" : "none",
            }}
            onClick={() => setActiveTab(index)}
          >
            {tab.title}
          </div>
        ))}
      </div>
      <div style={{ padding: "20px" }}>
        <p>{tabs[activeTab].content}</p>
      </div>
    </div>
  );
}

export default Tabs;

