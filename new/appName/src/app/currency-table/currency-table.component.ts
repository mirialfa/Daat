import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DateCurrenctRate } from '../Models/currency';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-currency-table',
  templateUrl: './currency-table.component.html',
  styleUrls: ['./currency-table.component.css']
})
export class CurrencyTableComponent implements OnInit {

  constructor(private http: HttpClient) { }
CurrencyDic:Map<number, DateCurrenctRate[]> | undefined;
currKind:number=2;
arr:any[]=[]
  ngOnInit(): void {
    
    this.onSelectKind();
  }

  onSelectKind(){
    this.http.get<Map<number,DateCurrenctRate[]>>(`${environment.endPoint}Coins/GetExchangeRate?kind=${this.currKind}`)
    .subscribe((data: Map<number,DateCurrenctRate[]>) => {
            this.CurrencyDic=data;
    });
  }

}
