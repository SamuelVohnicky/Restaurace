import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import Restaurant from './Restaurant';

export class Home extends Component {
    _isMounted = false;
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { restaurants: [] };
    }

    componentDidMount() {
        this.populateRestaurantData();
        this._isMounted = true;
    }

    componentWillUnmount() {
        this._isMounted = false;
    }

    onTermSubmit = async (review) => {
        let newState = { ...this.state.restaurants };
        let updatedRestaurant = newState[review.restaurantId -1];
        updatedRestaurant.reviews.push(review);
        console.log(newState);
        if (this._isMounted) {
            this.setState({ restaurants: newState });
        }
    }

  render () {
    return (
      <div className="card-collums">
            {this.renderRestaurants()}
      </div>
    );
    }

    async populateRestaurantData() {
        const token = await authService.getAccessToken();
        const response = await fetch('api/restaurants', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ restaurants: data });
        
    }

    renderRestaurants() {
        if (!this.state.restaurants.length) {
            return <div className="spinner-border"></div>;
        }
        return this.state.restaurants.map(restaurant => {
            return (
                <Restaurant key={restaurant.id} restaurant={restaurant} onTermSubmit={this.onTermSubmit} />
            );
        })
    }
}
