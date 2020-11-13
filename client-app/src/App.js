import logo from "./logo.svg";
import "./App.css";
import axios from 'axios';
function App() {
	axios.get('https://localhost:44360/', {
		
	})
	.then(result => console.log(result.data))
	.catch(err => console.log(err))
  return (
		<div className="App">
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				<p>
					Edit <code>src/App.js</code> and save to reload.
				</p>
				<a
					className="App-link"
					href="https://reactjs.org"
					target="_blank"
					rel="noopener noreferrer"
				>
					Learn React
				</a>
			</header>
		</div>
  );
}

export default App;
