import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Owner } from 'src/app/_interfaces/owner.model';
import { OwnerForCreation } from 'src/app/_interfaces/ownerForCreation.model';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { OwnerRepositoryService } from 'src/app/shared/services/owner-repository.service';

@Component({
  selector: 'app-owner-create',
  templateUrl: './owner-create.component.html',
  styleUrls: ['./owner-create.component.css']
})
export class OwnerCreateComponent implements OnInit {
  errorMessage: string = '';
  ownerForm: FormGroup;
  bsModalRef?: BsModalRef;

  constructor(private repository: OwnerRepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router, private datePipe: DatePipe, private modal: BsModalService) { }

    ngOnInit(): void {
      this.ownerForm = new FormGroup({
        name: new FormControl('',[Validators.required, Validators.maxLength(60)]),
        dateOfBirth: new FormControl('', [Validators.required]),
        address: new FormControl('',[Validators.required, Validators.maxLength(100)])
      });  
    }
    validateCrontrol = (controlName: string) => {
      if (this.ownerForm.get(controlName).invalid && this.ownerForm.get(controlName).touched)
      return true;

      return false;
    }
    hasError = (controlName: string, errorName: string) => {
      if (this.ownerForm.get(controlName).hasError(errorName))
      return true;

      return false
    }
}
