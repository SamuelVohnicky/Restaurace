import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

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
      <div>
        
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
}
