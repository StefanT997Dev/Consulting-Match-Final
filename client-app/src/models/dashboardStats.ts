import { DashboardUserDto } from "./dashboardUserDto";

export interface DashboardStats{
    followers:DashboardUserDto[];
    following:DashboardUserDto[];
}