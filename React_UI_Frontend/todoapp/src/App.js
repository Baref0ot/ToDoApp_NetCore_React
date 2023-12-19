import logo from './logo.svg';
import './App.css';
import { Component } from 'react';

class App extends Component{

  constructor(props){
    super(props);

    this.state = {
      notes : []
    }
  }



  API_URL = "http://localhost:42712/";


  // lifecycle method that is called when page is loaded
  componentDidMount(){
    this.refreshNotes();
  }



  async refreshNotes(){
    fetch(this.API_URL+"GetNotes").then(response => response.json())
    .then(data => {
      this.setState({notes:data});
    })
  }


 render() {
  const{notes}=this.state;

  return (
    <div className="App">
      <h2>To Do App</h2>
      {notes.map(note =>
        <p>
          <b>* {note.description}</b>
        </p>)}
    </div>
  );
}
}
export default App;
