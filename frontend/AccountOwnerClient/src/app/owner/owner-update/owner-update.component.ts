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

  constructor(private repository: OwnerRepositoryService, private errorHandler: ErrorHandlerService,
  private router: Router, private activeRoute: ActivatedRoute, private datePipe: DatePipe, 
  private modal: BsModalService) { }

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      name: new FormControl('',[Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });

    this.getOwnerById();
  }
  private getOwnerById = () => {
    const ownerId: string = this.activeRoute.snapshot.params['id'];
    const ownerByIdUri: string = `api/owner/${ownerId}`;

    this.repository.getOwner(ownerByIdUri)
    .subscribe({
      next: (own: Owner) => {
        this.owner = { ...own,
          dateOfBirth: new Date(this.datePipe.transform(own.dateOfBirth, 'MM/dd/yyyy'))
        };
        error: (err: HttpErrorResponse) => this.errorHandler.handleError(err)
        })
    }
    
  
