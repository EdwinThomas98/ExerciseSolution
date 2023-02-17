import { Injectable } from '@angular/core';
import { NgxConfigureService } from 'ngx-configure';
import { ToastrService } from 'ngx-toastr';
import { API_URL } from 'src/assets/utils/base_config';
import { HttpService } from 'src/core/httpservice';
import { UserDetailsModel } from './user-details.model';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {
  userList: UserDetailsModel[] = [];
  model = new UserDetailsModel();
  config: any;
  // to hide and show the form
  addOrEdit = false;

  constructor(public httpService: HttpService, public configService: NgxConfigureService, public toastrService: ToastrService) {
    this.config = configService.config;
  }

  // to get the user detail
  getUserDetails() {
    this.httpService.get(this.config.baseAPIURL + API_URL.GetUserDetails).subscribe({
      next: (response: any) => {
        this.userList = response;
      }
    });
  }

  // to delete the user details
  deleteUserDetails(model: any) {
    this.httpService.post(this.config.baseAPIURL + API_URL.DeleteUserDetails, model).subscribe({
      next: (response: any) => {
        this.toastrService.success(this.config.userDetails.userDeletedSuccessMessage);
        this.getUserDetails();
      }
    });
  }

  // to update the user details
  updateUserDetails(model: UserDetailsModel) {
    this.httpService.post(this.config.baseAPIURL + API_URL.UpdateUserDetails, model).subscribe({
      next: (response: any) => {
        this.addOrEdit = false;
        this.toastrService.success(this.config.userDetails.userUpdatedSuccessMessage);
        this.getUserDetails();
      }
    });
  }

  // to create the user details
  createUserDetails(model: UserDetailsModel) {
    this.httpService.post(this.config.baseAPIURL + API_URL.CreateUserDetails, model).subscribe({
      next: (response: any) => {
        this.addOrEdit = false;
        this.toastrService.success(this.config.userDetails.userCreatedSuccessMessage);
        this.getUserDetails();
      }
    });
  }
}
