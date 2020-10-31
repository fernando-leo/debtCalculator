import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public debts: Debt[];
  public phone: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.phone = "(14) 33332100";
    http.get<Debt[]>(baseUrl + 'debt').subscribe(result => {
      this.debts = result;
    }, error => console.error(error));
  }
}

interface Debt {
  OriginalValue: number;
  OriginalDate: Date;
  InterestType: number;
  Installments: number;
  FinalDate: Date;
  Comission: number;
  FinalValue: number;
}
