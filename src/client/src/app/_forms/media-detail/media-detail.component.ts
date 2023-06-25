import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { environment } from 'src/environments/environment';

let apiLoaded = false;

@Component({
  selector: 'app-media-detail',
  templateUrl: './media-detail.component.html',
  styleUrls: ['./media-detail.component.css'],
})
export class MediaDetailComponent implements OnInit {
  @Input() videos: any;
  @Input() images: any;
  modalRef?: BsModalRef;

  imageUrl = environment.imageUrl;

  constructor(private modalService: BsModalService) {}

  ngOnInit(): void {
    // if (!apiLoaded) this.loadiFrameAPI();
  }

  loadiFrameAPI() {
    const tag = document.createElement('script');
    tag.src = 'https://www.youtube.com/iframe_api';
    document.body.appendChild(tag);

    apiLoaded = true;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {
      ariaDescribedby: 'my-modal-description',
      ariaLabelledBy: 'my-modal-title',
    });
  }
}
