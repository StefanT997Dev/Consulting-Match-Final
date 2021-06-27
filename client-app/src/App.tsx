import React from "react";
import { Container } from "semantic-ui-react";
import Navbar from "./components/Navbar/Navbar";
import ConsultantDashboard from "./components/ConsultantDashboard/ConsultantDashboard";
import { observer } from "mobx-react-lite";
import { Route, Switch } from "react-router-dom";
import HomePage from "./containers/HomePage/HomePage";
import LandingPage from "./containers/LandingPage/LandingPage";
import AdminPanel from "./containers/AdminPanelPage/AdminPanelPage";
import LoginForm from "./forms/LoginForm/LoginForm";
import Profile from "./components/Profile/Profile";
import Calendly from "./components/Calendy/Calendly";
import TestErrors from "./components/TestError/TestError";
import { ToastContainer } from "react-toastify";
import NotFound from "./components/NotFoundError/NotFound";
import RegisterForm from "./forms/RegisterForm/RegisterForm";
import CategoriesForm from "./forms/CategoriesForm/CategoriesForm";

const App = () => {
  return (
    <div>
      <ToastContainer position="bottom-right" hideProgressBar />
      <Navbar />
      <div /*style={{ marginTop: "7em" }}*/>
        <Switch>
          <Route exact path="/" component={LandingPage} />
          <Route path="/manage" component={AdminPanel} />
          <Route path="/authentication" component={HomePage} />
          <Route path="/login" component={LoginForm} />
          <Route path="/register" component={RegisterForm} />
          <Route path="/categories" component={CategoriesForm} />
          <Route exact path="/consultants" component={ConsultantDashboard} />
          <Route path="/profile" component={Profile} />
          <Route path="/consultants/hire" component={Calendly} />
          <Route path="/consultants/:id" component={Profile} />
          <Route path="/errors" component={TestErrors} />
          <Route component={NotFound} />
        </Switch>
      </div>
    </div>
  );
};

export default observer(App);
