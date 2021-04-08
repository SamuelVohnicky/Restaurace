import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

class ReviewInput extends Component {
    state = {
        term: '',
        currentUserEmail: "",
        isAuthenticated: false
    };

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
        
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        console.log(user);
        this.setState({
            isAuthenticated
        });
        if (isAuthenticated) {
            this.setState({
                currentUserEmail: user.name
            });
        }
    }

    onInputChange = event => {
        this.setState({ term: event.target.value });
    };

    onFormSubmit = event => {
        event.preventDefault();
        console.log(this.state.term);
        this.postReview();
        
        
    };

    render() {
        return (
            <form onSubmit={this.onFormSubmit} style={{ marginTop: "10px" }} >
                    <div className="form-group">
                        <label>Napsat recenzi:</label>
                        <input
                            className="form-control"
                            placeholder="Recenze"
                            type="text"
                            value={this.state.term}
                            onChange={this.onInputChange}
                        />
                    </div>
                </form>
        );
    }
    async postReview() {
        const token = await authService.getAccessToken();
        let { currentUserEmail } = this.state;
        if (currentUserEmail === "") {
            currentUserEmail = "anonym"
        }
        fetch('api/reviews', {
            method: "POST",
            headers: {
                'Authorization': `Bearer ${ token }`,
            'Content-Type': 'application/json'
            },
    body: JSON.stringify({
        restaurantId: this.props.restaurantId,
        content: this.state.term,
        authorEmail: currentUserEmail
    })
        })
            .then(response => response.json())
    .then(data => {
        //mo�nost pracovat s odpov�d�
        //this.setState({ hasAnswered: true });
        console.log(data);
        this.setState({ term: "" });
    })
    .catch(error => {
        console.log(error);
    });
    }
}

export default ReviewInput;
