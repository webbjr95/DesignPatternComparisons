import { Component, OnInit } from '@angular/core';
import { FileTypes } from '../models/file-types';
import { PatternsService } from '../services/patterns.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(private patternsService: PatternsService) { }

  loading: boolean = false
  types: FileTypes = new FileTypes

  ngOnInit() { }

  onDownloadFluentBuilderReport(reportType: string) {
    this.loading = true;

    this.patternsService.getFluentBuilderReport(reportType).subscribe(response => {
      var type = this.types.GetFileExtensionFromMime(response.type)

      const a = document.createElement('a')
      a.href = URL.createObjectURL(response)
      a.download = `fluent-builder-report.${type}`
      a.click()
      this.loading = false;
    })
  }

  onDownloadStrategyReport(reportType: string) {
    this.loading = true;

    this.patternsService.getStrategyReport(reportType).subscribe(response => {
      var type = this.types.GetFileExtensionFromMime(response.type)

      const a = document.createElement('a')
      a.href = URL.createObjectURL(response)
      a.download = `strategy-report.${type}`
      a.click()
      this.loading = false;
    })
  }
}
