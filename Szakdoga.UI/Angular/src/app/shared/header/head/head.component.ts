import { Component, OnInit } from '@angular/core';
import { SyllabiService } from '../../services/syllabi.service';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'app-head',
  templateUrl: './head.component.html',
  styleUrls: ['./head.component.css'],
})
export class HeadComponent implements OnInit {
  canStart: boolean;

  mainSyllabikeys() {
    return Object.keys(this.syllabusService?.allMainSyllabi);
  }

  mainSelectedKey: string;

  mainSelected(id: string) {
    this.syllabusService?.changeActiveMainSyllabus(id);
  }

  specSyllabikeys() {
    return Object.keys(this.syllabusService?.allSpecForMain);
  }

  specSelectedKeys: string[];

  constructor(
    public syllabusService: SyllabiService,
    private events: EventService
  ) {
    this.canStart = false;
    events.subjectChanged.subscribe(x=>this.start());
  }

  specSelected() {
    this.syllabusService.selectMultibleSpec(this.specSelectedKeys);
    console.log('spec');
  }

  start() {
    this.mainSelectedKey = this.syllabusService.activeMainSyllabus.id;
    this.specSelectedKeys = [];
    this.syllabusService.selectedSpecSyllabi.forEach((x) =>
      this.specSelectedKeys.push(x.id)
    );
    this.canStart = true;
  }

  ngOnInit(): void {}
}
