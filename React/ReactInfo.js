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

/*
6. Toggle Visibility
Objective: Create a component that toggles the visibility of some content.
Requirements:
Use state to track whether the content is visible or hidden.
Display a "Toggle" button that shows/hides the content when clicked.
*/
import React, { useState } from "react";

function ToggleVisibility() {
  const [isVisible, setIsVisible] = useState(true);

  return (
    <div>
      <button onClick={() => setIsVisible(!isVisible)}>Toggle</button>
      {isVisible && <p>This content is visible!</p>}
    </div>
  );
}

export default ToggleVisibility;

/*
7. Stopwatch
Objective: Build a stopwatch component.
Requirements:
Display the elapsed time in seconds.
Add "Start," "Pause," and "Reset" buttons to control the timer.
*/
import React, { useState, useEffect } from "react";

function Stopwatch() {
  const [seconds, setSeconds] = useState(0);
  const [isRunning, setIsRunning] = useState(false);

  useEffect(() => {
    if (!isRunning) return;
    const interval = setInterval(() => setSeconds((s) => s + 1), 1000);
    return () => clearInterval(interval);
  }, [isRunning]);

  return (
    <div>
      <h1>Time: {seconds} seconds</h1>
      <button onClick={() => setIsRunning(true)}>Start</button>
      <button onClick={() => setIsRunning(false)}>Pause</button>
      <button onClick={() => { setSeconds(0); setIsRunning(false); }}>Reset</button>
    </div>
  );
}

export default Stopwatch;

/*
8. Dark Mode Toggle
Objective: Implement a dark mode toggle feature.
Requirements:
Use CSS classes to switch between dark and light themes.
Persist the theme selection using localStorage.
*/
import React, { useState, useEffect } from "react";

function DarkModeToggle() {
  const [isDarkMode, setIsDarkMode] = useState(() =>
    localStorage.getItem("theme") === "dark"
  );

  useEffect(() => {
    localStorage.setItem("theme", isDarkMode ? "dark" : "light");
    document.body.className = isDarkMode ? "dark-mode" : "light-mode";
  }, [isDarkMode]);

  return (
    <button onClick={() => setIsDarkMode(!isDarkMode)}>
      Toggle {isDarkMode ? "Light" : "Dark"} Mode
    </button>
  );
}

export default DarkModeToggle;

/*
9. Search Filter
Objective: Create a search bar that filters a list of items.
Requirements:
Use state to track the input value.
Filter and display items based on the input.
*/
import React, { useState } from "react";

function SearchFilter() {
  const [query, setQuery] = useState("");
  const items = ["Apple", "Banana", "Cherry", "Date", "Elderberry"];

  const filteredItems = items.filter((item) =>
    item.toLowerCase().includes(query.toLowerCase())
  );

  return (
    <div>
      <input
        type="text"
        placeholder="Search..."
        value={query}
        onChange={(e) => setQuery(e.target.value)}
      />
      <ul>
        {filteredItems.map((item, index) => (
          <li key={index}>{item}</li>
        ))}
      </ul>
    </div>
  );
}

export default SearchFilter;

/*
10. Accordion Component
Objective: Create a reusable accordion component.
Requirements:
Display multiple sections, each with a title and content.
Clicking on a section toggles its visibility.
*/
import React, { useState } from "react";

function Accordion() {
  const [activeIndex, setActiveIndex] = useState(null);

  const sections = [
    { title: "Section 1", content: "Content for Section 1" },
    { title: "Section 2", content: "Content for Section 2" },
    { title: "Section 3", content: "Content for Section 3" },
  ];

  const toggleSection = (index) =>
    setActiveIndex(activeIndex === index ? null : index);

  return (
    <div>
      {sections.map((section, index) => (
        <div key={index}>
          <h2 onClick={() => toggleSection(index)}>{section.title}</h2>
          {activeIndex === index && <p>{section.content}</p>}
        </div>
      ))}
    </div>
  );
}

export default Accordion;

/*
11. Form Validation
Objective: Build a login form with validation.
Requirements:
Use state to track username and password inputs.
Display error messages for empty fields.
*/
import React, { useState } from "react";

function LoginForm() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!username || !password) {
      setError("All fields are required!");
      return;
    }
    setError("");
    alert("Login Successful");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Username"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit">Login</button>
      {error && <p style={{ color: "red" }}>{error}</p>}
    </form>
  );
}

export default LoginForm;

/*
12. Tooltip Component
Objective: Create a tooltip that displays on hover.
Requirements:
Show a small tooltip when hovering over a target element.
*/
import React, { useState } from "react";

function Tooltip({ text, children }) {
  const [isVisible, setIsVisible] = useState(false);

  return (
    <div
      onMouseEnter={() => setIsVisible(true)}
      onMouseLeave={() => setIsVisible(false)}
      style={{ display: "inline-block", position: "relative" }}
    >
      {children}
      {isVisible && (
        <div
          style={{
            position: "absolute",
            bottom: "100%",
            background: "black",
            color: "white",
            padding: "5px",
            borderRadius: "4px",
          }}
        >
          {text}
        </div>
      )}
    </div>
  );
}

export default Tooltip;

/*
13. Image Gallery
Objective: Build an image gallery with thumbnails.
Requirements:
Clicking a thumbnail displays the full image.
*/
import React, { useState } from "react";

function ImageGallery({ images }) {
  const [selectedImage, setSelectedImage] = useState(images[0]);

  return (
    <div>
      <img src={selectedImage} alt="Selected" style={{ width: "100%" }} />
      <div>
        {images.map((img, index) => (
          <img
            key={index}
            src={img}
            alt="Thumbnail"
            style={{ width: "50px", cursor: "pointer" }}
            onClick={() => setSelectedImage(img)}
          />
        ))}
      </div>
    </div>
  );
}

export default ImageGallery;

/*
14. Star Rating Component
Objective: Create a star rating system.
Requirements:
Allow users to select a rating by clicking stars.
Highlight stars up to the selected rating.
*/
import React, { useState } from "react";

function StarRating({ maxStars = 5 }) {
  const [rating, setRating] = useState(0);

  return (
    <div>
      {[...Array(maxStars)].map((_, index) => (
        <span
          key={index}
          style={{
            fontSize: "2rem",
            cursor: "pointer",
            color: rating > index ? "gold" : "gray",
          }}
          onClick={() => setRating(index + 1)}
        >
          ★
        </span>
      ))}
    </div>
  );
}

export default StarRating;

/*
15. Drag and Drop
Objective: Implement a drag-and-drop list.
Requirements:
Allow users to reorder items by dragging.
*/
import React, { useState } from "react";
import { DragDropContext, Droppable, Draggable } from "react-beautiful-dnd";

function DragAndDrop() {
  const [items, setItems] = useState(["Item 1", "Item 2", "Item 3"]);

  const handleDragEnd = (result) => {
    if (!result.destination) return;

    const reorderedItems = Array.from(items);
    const [removed] = reorderedItems.splice(result.source.index, 1);
    reorderedItems.splice(result.destination.index, 0, removed);

    setItems(reorderedItems);
  };

  return (
    <DragDropContext onDragEnd={handleDragEnd}>
      <Droppable droppableId="list">
        {(provided) => (
          <ul {...provided.droppableProps} ref={provided.innerRef}>
            {items.map((item, index) => (
              <Draggable key={item} draggableId={item} index={index}>
                {(provided) => (
                  <li
                    ref={provided.innerRef}
                    {...provided.dr


