import logo from './logo.svg';
import './App.css';
import { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

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
        this.refreshNotes();
      })
  }// end addNote


  async deleteNote(id){
      const data = new FormData();
      data.append("id",id);

      fetch(this.API_URL+"DeleteNote", {
      method: "DELETE",
      body: data
    })
    .then(response => response.json())
    .then((result)=> {
      alert(result);
      this.refreshNotes();
    })
}// end deleteNote


 render() {
  const{notes}=this.state;

  return (
    <div class='container'>
      
      <div className='App'>
        <h2>To Do App</h2>
        <div class='card'>
        <ul class="list-group">
          {notes.map(note =>
          <li class="list-group-item">
            <div class='row'>              
                <div class='col-sm-9 d-flex justify-content-start'>
                  <b> {note.description} </b>
                </div>
                <div class='col-sm-3'>
                  <button onClick={() => this.deleteNote(note.id)} type="button" class="btn btn-danger"> Delete Note </button>       
                </div>           
            </div>
          </li>
          
          )}
          </ul>
        &nbsp;
        <div class='row'> 
          <div class='col-sm-3'></div>

            <div class='col-sm-6'>           
            <div class='input-group mb-3'> 
              <input class="form-control" id='newNotes' aria-describedby="basic-addon2" placeholder='Add a new note...'/> 
              <div class="input-group-append">
                <button onClick={() => this.addNote()} type='button' class='btn btn-success'> Add Note </button>    
              </div>
            </div>
          </div>
        </div>

        <div class='col-sm-3'></div>

      </div>
      </div>
    </div>
  );
}
}
export default App;
