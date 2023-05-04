import { Owner } from './../../_interfaces/owner.model';
import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OwnerForCreation } from 'src/app/_interfaces/ownerForCreation.model';

@Injectable({
  providedIn: 'root'
})
export class OwnerRepositoryService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getOwners = (route: string) => {
      return this.http.get<Owner[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    public getOwner = (route: string) => {
      return this.http.get<Owner>(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    public createOwner = (route: string, owner: OwnerForCreation
      ) => {
      return this.http.post<Owner>(this.createCompleteRoute(route, this.envUrl.urlAddress),
    owner, this.generateHeaders());
    }

    public updateOwner = (route: string, owner: OwnerForUpdate) => {
      return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), owner,
    this.generateHeaders());
    }

    public deleteOwner = (route: string) => {
      return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
      return `${envAddress}/${route}`;
    }

    private generateHeaders = () => {
      return {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      }
    }
  }
