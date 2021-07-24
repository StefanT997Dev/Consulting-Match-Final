import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import { history } from "../../";
import {
  Button,
  Container,
  Menu,
  Sidebar,
  Grid,
  Icon,
  Search,
  Segment,
  SearchProps,
  Image,
  Card,
  List,
  MenuItemProps,
} from "semantic-ui-react";
import agent from "../../api/agent";
import { MAX_MOBILE_SCREEN_WIDTH } from "../../constants";
import { isEmptyObject } from "../../util/data";
import { Category } from "../../models/category";
import { useStore } from "../../stores/store";

import "./Navbar.scss";
import { ConsultantSearchDto } from "../../models/consultantSearchDto";

export default function Navbar() {
  const currentUser = JSON.parse(localStorage.getItem("user") || "{}");
  const isLoggedIn = !isEmptyObject(currentUser);
  const {
    commonStore,
    userStore: { user, logout },
  } = useStore();

  const isAdmin = commonStore.getUserObject()?.role === "Admin" ? true : false;

  const [categories, setCategories] = useState<Category[]>([]);
  const [searchedName, setSearchedName] = useState<string | undefined>("");
  const [filteredConsultants, setFilteredConsultants] = useState<
    ConsultantSearchDto[] | undefined
  >([]);

  const { consultantStore } = useStore();

  const [width, setWidth] = useState(window.innerWidth);
  const [sidebarVisible, setSidebarVisible] = useState(false);
  const [activeItem, setActiveItem] = useState<string | undefined>(undefined);

  useEffect(() => {
    agent.Categories.list().then((response) => {
      setCategories(response);
    });
  }, []);

  useEffect(() => {
    const handleResize = () => {
      setWidth(window.innerWidth);
      if (window.innerWidth > MAX_MOBILE_SCREEN_WIDTH) setSidebarVisible(false);
    };

    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  const handleSearchChange = (
    event: React.MouseEvent<HTMLElement, MouseEvent>,
    data: SearchProps
  ) => {
    setSearchedName(data.value);

    filterConsultants(data.value);
  };

  const filterConsultants = async (skill: string | undefined) => {
    const consultants: ConsultantSearchDto[] = await agent.Consultants.search(
      skill
    );
    setFilteredConsultants(consultants);
  };

  const setActiveCategory = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    data: MenuItemProps
  ) => {
    setActiveItem(data.name);
  };

  const filterConsultantsByCategory = (activeCategory:string|undefined) => {
    console.log(consultantStore.consultants);
    console.log(consultantStore.currentConsultants);
    
    consultantStore.currentConsultants = consultantStore.consultants.filter(
      (c) => c.categories[0] === activeCategory
    );
  };

  const tabs = (
    <React.Fragment>
      <Menu.Item as={NavLink} to="/" exact>
        Home
      </Menu.Item>
      {!isLoggedIn ? (
        <Menu.Item header as={NavLink} to="/authentication" exact>
          ConsultingMatch
        </Menu.Item>
      ) : null}
      {isAdmin && (
        <Menu.Item as={NavLink} to="/manage">
          Admin panel
        </Menu.Item>
      )}

      <Menu.Item as={NavLink} to="/profile" exact>
        Profile
      </Menu.Item>
      <Menu.Item style={{ width: "45em" }}>
        <Grid>
          <Grid.Column width={8}>
            <Search
              fluid
              input={{ fluid: true }}
              style={{ width: "600px" }}
              loading={false}
              placeholder="Type any skill you want to learn"
              onSearchChange={handleSearchChange}
              results={filteredConsultants}
              value={searchedName}
            />
          </Grid.Column>
        </Grid>
        <div className="consultantDisplayList">
          <List>
            {filteredConsultants?.map((consultant) => (
              <List.Item>
                <Image
                  avatar
                  src="https://react.semantic-ui.com/images/avatar/small/rachel.png"
                />
                <List.Content>
                  <List.Header as="a">{consultant.displayName}</List.Header>
                  <List.Description>
                    <List horizontal>
                      <List.Item>
                        {consultant.skills.map((skill) => (
                          <List.Description>{skill.name}</List.Description>
                        ))}
                      </List.Item>
                    </List>
                  </List.Description>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </div>
      </Menu.Item>
      {isLoggedIn && (
        <Menu.Item
          onClick={() => {
            logout();
            history.replace("/");
          }}
          position="right"
        >
          Logout
        </Menu.Item>
      )}
    </React.Fragment>
  );

  return (
    <div>
      {width > MAX_MOBILE_SCREEN_WIDTH ? (
        <Menu
          className="navbar"
          style={{ marginTop: "0px", marginBottom: "0px" }}
          inverted
        >
          <Container>{tabs}</Container>
        </Menu>
      ) : (
        <Segment className="navbar" inverted size="tiny">
          <Icon
            size="big"
            name="sidebar"
            onClick={() => setSidebarVisible(true)}
          />
          <Sidebar
            inverted
            as={Menu}
            width="thin"
            vertical
            visible={sidebarVisible}
            onHide={() => setSidebarVisible(false)}
          >
            {tabs}
          </Sidebar>
        </Segment>
      )}
      {window.location.href === "http://localhost:3000/consultants" ? (
        <Menu
          className="navbar"
          style={{ marginTop: "0px", marginBottom: "0px" }}
          inverted
          fluid
        >
          <Container>
            {categories.map((category) => (
              <Menu.Item
                name={category.name}
                active={activeItem === category.name}
                color="blue"
                onClick={(event, data) => {setActiveCategory(event, data);filterConsultantsByCategory(data.name);}}
              ></Menu.Item>
            ))}
          </Container>
        </Menu>
      ) : null}
    </div>
  );
}
