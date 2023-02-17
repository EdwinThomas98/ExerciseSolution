import { NgxConfigureOptions } from 'ngx-configure';

// to configure the options to use the config file
export class MyOptions extends NgxConfigureOptions {
    override ConfigurationURL = '/assets/resources/config.json';
}

// to configure all the api url
export const API_URL = {
    GetUserDetails: "UserDetails/GetUserDetails",
    DeleteUserDetails: "UserDetails/DeleteUserDetails",
    UpdateUserDetails: "UserDetails/UpdateUserDetails",
    CreateUserDetails: "UserDetails/CreateUserDetails"
}