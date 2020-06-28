import React, {Component} from 'react';

import './App.css';
const API = "/test"

class App extends Component {
  constructor(props){
    super(props);
    this.state = {
      data: []
    };
  }
  async componentDidMount(){
    const url = API;
    const response = await fetch(url);
    console.log(response);
    const data = await response.json();
    console.log(data);
    this.setState({books:data,loading:false});
  }
  createTableHeaders(){
    return <tr>
      <th>Title</th>
      <th>Author</th>
      <th>Release Date</th>
      <th>Genre</th>
      <th>Price</th>
    </tr>
  }
  createTableData(){
    return this.state.books.map((myBook,index)=>{
      const{id,title,author,releaseDate,genre,price} = myBook;
      return(
        <tr key={id}>
          <td>{title}</td>
          <td>{author}</td>
          <td>{releaseDate}</td>
          <td>{genre}</td>
          <td>{price}</td>
        </tr>
      )
    })
  }
  render(){
    if(this.state.loading){
      return <div>loading...</div>
    }
    if(!this.state.books){
      return <div>Did not find any books</div>
    }
    return (
      <div className="App">
        <table class="table table-striped table-bordered table-hover">
          <tbody>
            {this.createTableHeaders()}
            {this.createTableData()}
          </tbody>
        </table>
        <a href="https://localhost:5001/Books/Create">Add New </a>
      </div>
    )
  }
  
}

export default App;
