import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'
import ReviewInput from './ReviewInput';

class ReviewList extends Component {
    static displayName = ReviewList.name;

    constructor(props) {
        super(props);
        this.state = { restaurants: [], loading: true };
    }

  render () {
      return (
          <div>
              <h4>Recenze</h4>
              <ul className="list-group">
                  {this.renderReviews()}
              </ul>
              <ReviewInput restaurantId={this.props.restaurantId}/>
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

    renderReviews() {
        if (!this.props.reviews.length) {
            return <h2 className="display-4">Žádné restaurace nebyli nalezeny.</h2>;
        }
        return this.props.reviews.map(review => {
            return (
                <li key={review.id} className="list-group-item">
                    <strong>{review.authorEmail}</strong><br/>
                    {review.content}
                </li>
            );
        })
    }
}
export default ReviewList;
