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
