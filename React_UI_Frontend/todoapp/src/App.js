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
  }// end refreshNotes


  async addNote(){
      var newNoteInput = document.getElementById("newNotes").value;
      const data = new FormData();
      data.append("newNote",newNoteInput);

      fetch(this.API_URL+"AddNote", {
        method: "POST",
        body: data
      })
      .then(response => response.json())
      .then((result)=> {
        alert(result);
        this.refreshNotes()
      })
  }// end AddNote


 render() {
  const{notes}=this.state;

  return (
    <div className="App">
      <h2>To Do App</h2>
      <input id="newNotes" />&nbsp;
      <button onClick={() => this.addNote()} type="button"> Add Note </button>
      {notes.map(note =>
        <p>
          <b>* {note.description}</b>&nbsp;
          <button onClick={() => this.deleteNote(note.id)} type="button"> Delete Note </button>
        </p>)}
    </div>
  );
}
}
export default App;
