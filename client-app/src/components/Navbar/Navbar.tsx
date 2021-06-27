import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import {
  Button,
  Container,
  Menu,
  Image,
  Grid,
  Search,
  SearchProps,
} from "semantic-ui-react";
import { SemanticWIDTHS } from "semantic-ui-react/dist/commonjs/generic";
import agent from "../../api/agent";
import { Category } from "../../models/category";
import { useStore } from "../../stores/store";

export default observer(function Navbar() {
  const activeColor = "blue";

  const { consultantStore } = useStore();
  const { categoryStore } = useStore();
  const {
    userStore: { user },
  } = useStore();

  const [categories, setCategories] = useState<Category[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [searchedName, setSearchedName] = useState<string | undefined>("");

  useEffect(() => {
    agent.Categories.list().then((response) => {
      setCategories(response);
    });
  }, []);

  const handleSearchChange = (
    event: React.MouseEvent<HTMLElement, MouseEvent>,
    data: SearchProps
  ) => {
    setIsLoading(true);
    setSearchedName(data.value);

    consultantStore.filterConsultants(data.value);
  };

  return (
    <div>
      <Menu style={{ marginTop: "0px", marginBottom: "0px" }} inverted>
        <Container>
          <Menu.Item as={NavLink} to="/" exact>
            Home
          </Menu.Item>
          <Menu.Item header as={NavLink} to="/authentication" exact>
            {/* <img src="/assets/logo.png" alt="logo" /> */}
            ConsultingMatch
          </Menu.Item>
          <Menu.Item
            //TODO: need to protect this route if user is not admin
            as={NavLink}
            to="/manage"
          >
            Admin panel
          </Menu.Item>
          {/* <Menu.Item name="Feed" as={NavLink} to="/feed" /> */}
          <Menu.Item as={NavLink} to="/profile">
            <Button positive content="Profile" />
          </Menu.Item>
          <Menu.Item style={{ width: "45em" }}>
            <Grid>
              <Grid.Column width={8}>
                <Search
                  fluid
                  input={{ fluid: true }}
                  style={{ width: "600px" }}
                  loading={isLoading}
                  onSearchChange={handleSearchChange}
                  results={consultantStore.filteredConsultants}
                  value={searchedName}
                />
              </Grid.Column>
            </Grid>
          </Menu.Item>
          {/* <Menu.Item name="Errors" as={NavLink} to="/errors" /> */}
          {/* <Menu.Item position="right">
            <Image
              src={user?.image || "/images/homersimpson.0.0.jpg"}
              avatar
              spaced="right"
            />
          </Menu.Item> */}
        </Container>
      </Menu>

      {/* <Menu
        style={{ marginTop: "1px", marginBottom: "0px" }}
        inverted
        widths={categories.length as SemanticWIDTHS}
      >
        {categories.map((category) => (
          <Menu.Item
            key={category.id}
            name={category.name}
            active={categoryStore.activeCategoryName === category.name}
            color={activeColor}
            onClick={(event, data) => {
              categoryStore.handleActiveCategoryName(event, data);
              consultantStore.loadConsultantsForSelectedCategory(
                categoryStore.activeCategoryName
              );
            }}
          />
        ))}
      </Menu> */}
    </div>
  );
});
