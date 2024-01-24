import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataSchemeDto } from 'src/model/data-scheme/dtos/dataSchemeDto';
import { GetDataSchemeRequest } from 'src/model/data-scheme/requests/GetDataSchemeRequest';

@Injectable({
    providedIn: 'root'
})
export class DataSchemeService {
    private baseUrl = 'https://localhost:5001/api/datascheme';

    constructor(private http: HttpClient) {}

    getDataScheme(connectionString: string): Observable<DataSchemeDto> {
        return this.http.post<DataSchemeDto>(`${this.baseUrl}/getScheme`, new GetDataSchemeRequest({
            connectionString : connectionString
        }));
    }
}

