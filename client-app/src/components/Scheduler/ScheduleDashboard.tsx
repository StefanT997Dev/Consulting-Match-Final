import React, { useState } from "react";
import {
  DateInput,
  TimeInput,
  DateTimeInput,
  DatesRangeInput,
} from "semantic-ui-calendar-react";
import { Button, Segment } from "semantic-ui-react";
import agent from "../../api/agent";
import {ScheduleDto} from '../../models/scheduleDto';
import { useStore } from "../../stores/store";
import { parseISO } from 'date-fns' 

export default function ScheduleDashboard() {
  const [valueOfDateAndTime, setValueOfDateAndTime] = useState<string>("");
  const [schedule,setSchedule]=useState<ScheduleDto>();
  const {commonStore,consultantStore}=useStore();

  const handleChange = (
    e: React.SyntheticEvent<HTMLElement, Event>,
    data: any
  ) => {
    debugger
    setValueOfDateAndTime(data.value);
    setSchedule({targetConsultantId:consultantStore.selectedConsultant?.id,startDateAndTime:parseISO(data.value),endDateAndTime:parseISO(data.value)});
  };

  const scheduleAConsultingSession= async ()=>{
    debugger
    await agent.Schedule.create(schedule!,commonStore.token);
  }

  return (
    <Segment textAlign='center'>
      <DateTimeInput
        name="dateTime"
        placeholder="Date Time"
        value={valueOfDateAndTime}
        iconPosition="left"
        onChange={handleChange}
      />
      <Button onClick={scheduleAConsultingSession} primary>Schedule a consulting session</Button>
    </Segment>
  );
}
