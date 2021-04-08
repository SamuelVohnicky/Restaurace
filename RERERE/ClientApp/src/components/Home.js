import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import Restaurant from './Restaurant';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { restaurants: [], loading: true };
    }

    componentDidMount() {
        this.populateRestaurantData();
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
        this.setState({ restaurants: data, loading: false });
        console.log(data);
    }

    renderRestaurants() {
        if (!this.state.restaurants.length) {
            return <h2 className="display-4">��dn� restaurace nebyli nalezeny.</h2>;
        }
        return this.state.restaurants.map(restaurant => {
            return (
                <Restaurant key={restaurant.id} restaurant={restaurant} />
            );
        })
    }
}
