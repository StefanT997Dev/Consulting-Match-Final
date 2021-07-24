import React from "react";
import ReactDOM from "react-dom";
import "semantic-ui-css/semantic.min.css";
import "./styles.scss";
import "react-toastify/dist/ReactToastify.min.css";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import { store, StoreContext } from "./stores/store";
import { Router } from "react-router-dom";
import { createBrowserHistory } from "history";

export const history = createBrowserHistory();

ReactDOM.render(
  <StoreContext.Provider value={store}>
    <Router history={history}>
      <App />
    </Router>
  </StoreContext.Provider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
