import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Owner } from 'src/app/_interfaces/owner.model';
import { OwnerForUpdate } from 'src/app/_interfaces/ownerForUpdate.model';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component'; 
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { OwnerRepositoryService } from 'src/app/shared/services/owner-repository.service';

@Component({
  selector: 'app-owner-update',
  templateUrl: './owner-update.component.html',
  styleUrls: ['./owner-update.component.css']
})
export class OwnerUpdateComponent implements OnInit {
  owner: Owner;
  ownerForm: FormGroup;
  bsModalRef?:BsModalRef;

  constructor(private repository: OwnerRepositoryService, private errorHandler: ErrorHandlerService,)
}
