import React from "react";
import { observer } from "mobx-react-lite";
import { Container, Grid } from "semantic-ui-react";
import { useStore } from "../../stores/store";
import ConsultantDetails from "../ConsultantDetails/ConsultantDetails";
import ConsultantContactForm from "../../forms/ConsultantContractForm/ConsultantContact";
import ConsultantList from "../ConsultantList/ConsultantList";

export default observer(function ConsultantDashboard() {
  const { consultantStore } = useStore();
  const { commonStore } = useStore();

  return (
    <Container>
      <Grid>
        <Grid.Column width="10">
          {consultantStore.consultants ? <ConsultantList /> : null}
        </Grid.Column>
        <Grid.Column width="6">
          {consultantStore.selectedConsultant && <ConsultantDetails />}
          {commonStore.displayConsultantContact ? (
            <ConsultantContactForm />
          ) : null}
        </Grid.Column>
      </Grid>
    </Container>
  );
});
