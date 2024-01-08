import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataSchemeDto } from 'src/model/data-scheme/dataSchemeDto';

@Injectable({
    providedIn: 'root'
})
export class DataSchemeService {
    private baseUrl = 'https://localhost:5001/api/datascheme';

    constructor(private http: HttpClient) {}

    getDataScheme(): Observable<DataSchemeDto> {
        return this.http.get<DataSchemeDto>(`${this.baseUrl}`);
    }
}

