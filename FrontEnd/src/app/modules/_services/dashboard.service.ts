import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DashboardService {

    baseUrl = environment.KUPFApiUrl;
    constructor(private httpClient: HttpClient) {

    }

    GetDashBoardData(tenantId: number, locationId: number) {
        return this.httpClient.get(this.baseUrl + `DashBoard/GetDashBoardData?tenentid=${tenantId}&locationId=${locationId}`);
    }

}
