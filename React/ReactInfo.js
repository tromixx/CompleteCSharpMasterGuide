// React Interview Questions Guide

// Basics

/**
 * What is React?
 * React is a JavaScript library for building user interfaces. It focuses on
 * declarative, component-based architecture, allowing developers to build reusable UI components.
 */

/**
 * What are components in React?
 * Components are the building blocks of a React application. They can be:
 * - Functional Components: Written as JavaScript functions.
 * - Class Components: Written as ES6 classes extending React.Component.
 */

/**
 * What is the Virtual DOM?
 * The Virtual DOM is a lightweight copy of the real DOM. React uses it to improve performance by minimizing direct DOM manipulations.
 */

/**
 * What is JSX?
 * JSX stands for JavaScript XML. It is a syntax extension for writing HTML-like code inside JavaScript files. JSX gets transpiled into React.createElement calls.
 */

/**
 * What are props in React?
 * Props (short for properties) are read-only inputs passed from a parent component to a child component.
 */

/**
 * What is state in React?
 * State is a built-in object used to hold data that affects the rendering of components. It is local and mutable.
 */

// Intermediate

/**
 * What is the difference between state and props?
 * - State is mutable and managed within a component.
 * - Props are immutable and passed from parent to child components.
 */

/**
 * What are React Hooks?
 * Hooks are functions introduced in React 16.8 that let developers use state and lifecycle features in functional components. Examples include:
 * - useState: For state management.
 * - useEffect: For side effects.
 * - useContext: For accessing Context API.
 */

/**
 * What is the Context API?
 * The Context API provides a way to share values like themes or user authentication across components without prop drilling.
 */

/**
 * What is the difference between controlled and uncontrolled components?
 * - Controlled Components: Form inputs controlled by React state.
 * - Uncontrolled Components: Form inputs controlled by the DOM.
 */

/**
 * What is a key in React?
 * Keys are unique identifiers used to identify elements in a list. They help React optimize rendering by tracking changes efficiently.
 */

/**
 * What is useEffect?
 * useEffect is a React Hook used for handling side effects like data fetching, subscriptions, or manual DOM manipulation.
 */

// Advanced

/**
 * What is server-side rendering (SSR)?
 * SSR renders React components on the server and sends HTML to the browser. It improves performance and SEO.
 */

/**
 * What are higher-order components (HOCs)?
 * HOCs are functions that take a component as input and return an enhanced component. Example:
 */
function withLogging(WrappedComponent) {
  return function EnhancedComponent(props) {
    console.log('Rendering Component');
    return <WrappedComponent {...props} />;
  };
}

/**
 * What are React portals?
 * Portals let you render children into a DOM node outside the parent component hierarchy. Example:
 */
ReactDOM.createPortal(
  <ChildComponent />, // JSX
  document.getElementById('portal-root') // Target DOM Node
);

/**
 * How can you optimize performance in React?
 * - Use React.memo to memoize functional components.
 * - Use useMemo to memoize values.
 * - Use useCallback to memoize functions.
 * - Lazy load components with React.lazy.
 * - Split code using React.Suspense.
 */

/**
 * What is the difference between useMemo and useCallback?
 * - useMemo: Memoizes a value.
 * - useCallback: Memoizes a function.
 */

/**
 * What is Redux?
 * Redux is a state management library often used with React. It stores the entire application state in a single store.
 */

// Testing and Debugging

/**
 * How do you handle errors in React?
 * Use Error Boundaries to catch errors in the component tree. Example:
 */
class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false };
  }

  static getDerivedStateFromError(error) {
    return { hasError: true };
  }

  componentDidCatch(error, info) {
    console.log(error, info);
  }

  render() {
    if (this.state.hasError) {
      return <h1>Something went wrong.</h1>;
    }
    return this.props.children;
  }
}

/**
 * How do you test React applications?
 * Use tools like Jest and React Testing Library for unit and integration testing. Example:
 */
import { render, screen } from '@testing-library/react';
import MyComponent from './MyComponent';

test('renders component', () => {
  render(<MyComponent />);
  const element = screen.getByText(/example/i);
  expect(element).toBeInTheDocument();
});

// Behavioral

/**
 * Describe a challenging React project and how you solved the issues.
 * Provide a detailed explanation of the project and the techniques used to resolve problems.
 */

/**
 * How do you manage large-scale applications in React?
 * - Modularize the codebase.
 * - Use Context API or state management libraries.
 * - Optimize performance using React.memo and code-splitting.
 */

// Additional Questions

/**
 * What are React Fragments?
 * Fragments let you group a list of children without adding extra nodes to the DOM. Example:
 */
<>
  <Child1 />
  <Child2 />
</>;

/**
 * What is React StrictMode?
 * StrictMode is a tool for highlighting potential problems in an application. It runs in development mode only.
 */

/**
 * What is the difference between React and Angular?
 * Compare features like architecture, performance, and community support.
 */
