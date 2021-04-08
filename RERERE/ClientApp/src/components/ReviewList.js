import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'
import ReviewInput from './ReviewInput';

class ReviewList extends Component {
    static displayName = ReviewList.name;

    

  render () {
      return (
          <div>
              <h4>Recenze</h4>
              <ul className="list-group">
                  {this.renderReviews()}
              </ul>
              <ReviewInput restaurantId={this.props.restaurantId} onTermSubmit={this.props.onTermSubmit}/> 
          </div>
      
    );
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
