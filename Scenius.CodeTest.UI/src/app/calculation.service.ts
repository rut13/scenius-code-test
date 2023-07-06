import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CalculationResult } from './app.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculationService {

  private calcUrl = 'http://localhost:5000/Calculator';

  constructor(private http: HttpClient) { }

  getCalculations(): Observable<CalculationResult[]> {
    return this.http.get<CalculationResult[]>(this.calcUrl + '/all');
  }

  doCalculation(calculate: string): Observable<CalculationResult> {
    this.http.post(this.calcUrl, JSON.stringify(calculate), { headers: new HttpHeaders().append('Content-Type','application/json' )}).subscribe();
    return this.http.get<CalculationResult>(this.calcUrl);
  }
}
