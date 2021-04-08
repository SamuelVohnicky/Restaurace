import React, { Component } from 'react';
import ReviewList from './ReviewList'

class Restaurant extends Component {
    static displayName = Restaurant.name;

   

  render () {
    return (
        <div className="card" style={{marginTop: "20px"}}>
            
                <div className="card-body">
                <h5 className="card-title">{this.props.restaurant.name}</h5>
                <p className="card-text">
                    Informace o restauraci.
                    <br/>...
                    <br/>...
                    <br/>... 
                </p>
                </div>
                <div className="card-footer">
                <ReviewList reviews={this.props.restaurant.reviews} />
                </div>
        </div>
    );
    }

}
export default Restaurant;
