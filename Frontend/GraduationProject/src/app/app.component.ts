import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'GraduationProject';
  public screen: string = 'Yönetim Paneline Git';
  private isAdminPanel = false;
  private subs: any;

  constructor(private router: Router) {
    this.subs = router.events.subscribe((x) => {
      if (x instanceof NavigationEnd) {
        if (x.url.includes('registration'))
          this.screen = 'Yönetim Paneline Git';
        else {
          this.isAdminPanel = true;
          this.screen = 'Kayıt Paneline Git';
        }
      }
    });
  }

  changeScreen() {
    if (this.isAdminPanel) {
      this.router.navigate(['registration']);
    } else {
      this.router.navigate(['management']);
    }
  }
}
