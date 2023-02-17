import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserDetailsModel } from './user-details.model';
import { UserDetailsService } from './user-details.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent {

  public form!: FormGroup;
  // to change the static text based on create or update
  textproperty = '';
  // to set the model selected based on the events
  selectedmodel: UserDetailsModel | undefined;

  constructor(public coreService: UserDetailsService, public formBuilder: FormBuilder) { }

  // loads when the component is loaded
  ngOnInit() {
    this.setValidationRequiredFields();
    this.coreService.getUserDetails();
  }

  // to set the form validations
  setValidationRequiredFields() {
    this.form = new FormGroup({
      userId: new FormControl(this.coreService.model.userId),
      firstName: new FormControl(this.coreService.model.firstName, [Validators.required]),
      lastName: new FormControl(this.coreService.model.lastName, [Validators.required]),
      dob: new FormControl(this.coreService.model.dob, [Validators.required]),
      mobileNumber: new FormControl(this.coreService.model.mobileNumber, [Validators.required, Validators.pattern(/^\d+\.?\d*$/)]),
      email: new FormControl(this.coreService.model.email, [Validators.required, Validators.email])
    });
  }

  // triggers when the delete button is clicked
  deleteUser(userId: number) {
    this.coreService.addOrEdit = false;
    // to alert the user
    if (confirm(this.coreService.config.userDetails.deleteConfirmationMessage)) {
      this.selectedmodel = this.coreService.userList.find(x => x.userId == userId);
      this.coreService.deleteUserDetails(this.selectedmodel);
    }
  }

  // triggers when the edit button is triggered
  editUser(id: number) {
    this.coreService.addOrEdit = true;
    if (this.selectedmodel?.userId != id) {
      this.selectedmodel = this.coreService.userList.find(x => x.userId == id);
      this.textproperty = this.coreService.config.userDetails.editUserMessage + this.selectedmodel?.firstName + ' ' + this.selectedmodel?.lastName;
      //to set the form value
      this.form.setValue({
        firstName: this.selectedmodel?.firstName,
        lastName: this.selectedmodel?.lastName,
        dob: this.selectedmodel?.dob,
        userId: this.selectedmodel?.userId,
        mobileNumber: this.selectedmodel?.mobileNumber,
        email: this.selectedmodel?.email
      });
    }
  }

  // triggers when the create button is clicked
  addUser() {
    this.textproperty = this.coreService.config.userDetails.createUserMessage;
    this.form.reset();
    this.coreService.addOrEdit = true;
  }

  // triggers when the save button is clicked
  onFormSubmit() {
    this.form.markAllAsTouched();
    this.coreService.model = this.form.value;
    if (this.form.valid) {
      if (this.coreService.model.userId > 0) {
        this.coreService.updateUserDetails(this.coreService.model);
      } else {
        this.coreService.createUserDetails(this.coreService.model);
      }
    }
  }

  // triggers when the cancel button is clicked
  onCancelForm() {
    this.form.reset();
    this.coreService.addOrEdit = false;
  }
}
