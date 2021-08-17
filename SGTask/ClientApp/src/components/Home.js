import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h1>Age predictions based on a name!</h1>
            <br/>
            <label>Input a name below</label>
            <br/>
            <input id="nameInput"></input>
            <button onClick={() => { this.GetAgePrediction() }} >Get Age Prediction</button>
        
      </div>
    );
    }

    async GetAgePrediction() {
        const response = await fetch('ageprediction');
        const data = await response.json();
        alert("Predicted age for " + data.name + " is : " + data.age);
    }
}
