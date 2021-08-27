import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class PatternsService {
  constructor(private http: HttpClient) { }

  reportsBaseUrl: string = 'https://localhost:5001/api/v1/Reports'

  getFluentBuilderReport(reportType: string) {
    const href = `${this.reportsBaseUrl}/${reportType}FluentBuilder`

    return this.http.get(href, {
      responseType: 'blob'
    })
  }

  getStrategyReport(reportType: string){
    return this.http.get(`${this.reportsBaseUrl}/${reportType}Strategy`, {
      responseType: 'blob'
    })
  }
}
