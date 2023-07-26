import {BehaviorSubject, Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {userLoginRequest} from "../models/userLoginRequest.model";
import {Injectable} from "@angular/core";
import {UserModel} from "../models/user.model";
import {Router} from "@angular/router";

@Injectable()
export class AppAuthService{
  user: BehaviorSubject<UserModel | null> = new BehaviorSubject<UserModel | null>(null);

  constructor(private _httpClient: HttpClient, private _router: Router) {
  }

  sendLoginRequest(username:string, password: string) {
    const userLoginRequest: userLoginRequest = {
      username: username,
      password: password
    };

    this._httpClient.post<any>('/auth', userLoginRequest).subscribe(
      (response) => {
        if(response.success && response.username === username){
          const info = new UserModel(response.id, response.username);
          this.user.next(info);
          this._router.navigate(['']);
        }
        else{
          console.log("wrong pass");
        }
      },
      (error) => {
        // Handle any errors that occurred during the request

        console.error('Error:', error);
      }
    );
  }

  Logout(){
    this.user.next(null)
    this._router.navigate(['Login'])
  }
}

interface User{
  username: string;
}
