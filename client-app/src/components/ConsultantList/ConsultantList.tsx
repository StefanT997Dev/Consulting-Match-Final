import React, { useEffect, useState } from "react";
import {
  Item,
  Menu,
  MenuItemProps,
  Pagination,
  PaginationProps,
} from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../stores/store";
import ConsultantListItem from "../ConsultantListItem/ConsultantListItem";

export default observer(function ConsultantList() {
  const { consultantStore } = useStore();

  useEffect(() => {
    consultantStore.loadConsultants();
    consultantStore.currentConsultants = consultantStore.consultants;
  }, [consultantStore]);

  const [activeItem, setActiveItem] = useState<string | undefined>("topRated");
  const [activePage, setActivePage] = useState<any>(1);
  const arrayForPagination: number[] = [0, 3, 6, 9];

  const handleItemClick = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    data: MenuItemProps
  ) => {
    setActiveItem(data.name);
    data.name === "topRated" ? sortByTopRated() : sortByMostReviews();
  };

  const sortByMostReviews = () => {
    consultantStore.currentConsultants.sort((a, b) =>
      a.numberOfReviews < b.numberOfReviews ? 1 : -1
    );
  };

  const sortByTopRated = () => {
    consultantStore.currentConsultants.sort((a, b) =>
      a.averageStarReview < b.averageStarReview ? 1 : -1
    );
  };

  const handlePageChange = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    data: PaginationProps
  ) => {
    setActivePage(data.activePage);
  };

  return (
    <div>
      <Menu text>
        <Menu.Item header>Sort By</Menu.Item>
        <Menu.Item
          name="topRated"
          active={activeItem === "topRated"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="mostReviews"
          active={activeItem === "mostReviews"}
          onClick={handleItemClick}
        />
      </Menu>

      <Item.Group divided>
        {consultantStore.currentConsultants
          .slice(
            activePage + arrayForPagination[activePage - 1] - 1,
            activePage === 1 ? activePage * 4 : activePage * 4 - 1
          )
          .map((consultant) => (
            <ConsultantListItem consultant={consultant} />
          ))}
      </Item.Group>

      <Pagination
        defaultActivePage={1}
        onPageChange={handlePageChange}
        firstItem={null}
        lastItem={null}
        pointing
        secondary
        totalPages={Math.ceil(consultantStore.currentConsultants.length / 4)}
      />
    </div>
  );
});
