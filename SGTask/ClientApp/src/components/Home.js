import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h1>Age predictions based on a name!</h1>
            <br />

            <label>Input a single name below</label>
            <br/>
            <input id="nameInput"></input>
            <button onClick={() => { this.GetAgePrediction() }} >Get Age Prediction</button>
            <br />
            <br />

            <label>Input Multiple names below seperated by a ','</label>
            <br />
            <input id="multiInput"></input>
            <button onClick={() => { this.GetMultiAgePrediction() }} >Get Age Predictions</button>
      </div>
    );
    }

    

    async GetAgePrediction() {
        let inputProperty = document.getElementById("nameInput")
        const response = await fetch('ageprediction/' + inputProperty.value);
        const data = await response.json();
        alert("Predicted age for " + data.name + " is : " + data.age);
    }

    async GetMultiAgePrediction() {
        let inputProperty = document.getElementById("multiInput")
        const response = await fetch('multiageprediction/' + inputProperty.value);
        const data = await response.json();
        alert("Predicted age for " + data.name + " is : " + data.age);
    }

    
}
