import {
  Directive,
  ElementRef,
  HostListener,
  Input
} from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {

  @Input() appHighlight = '#dbeafe';

  constructor(private el: ElementRef) {}

  @HostListener('mouseenter')
  onMouseEnter() {

    this.el.nativeElement.style.backgroundColor =
      this.appHighlight;

    this.el.nativeElement.style.transition =
      '0.3s';

  }

  @HostListener('mouseleave')
  onMouseLeave() {

    this.el.nativeElement.style.backgroundColor =
      '';

  }

}