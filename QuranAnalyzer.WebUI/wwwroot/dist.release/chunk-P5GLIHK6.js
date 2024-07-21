import{a as q,b as Te}from"./chunk-ONNXD5GY.js";import{b as ye}from"./chunk-5CPDVWWS.js";import{a as pe}from"./chunk-LLTZKMJJ.js";import{S as Y,T as Z,b as W,c as F,d as a,w as de,x as he,y as J}from"./chunk-KH7ZNKZE.js";import{a as G,m as Q}from"./chunk-2JQQM347.js";import{a as ie}from"./chunk-EMKQGYXC.js";import{e as _}from"./chunk-PU6LYOEU.js";var p=_(ie());var t=_(ie());var ee=_(ie());var le=_(G());function We(s){let{className:x,classes:l,pulsate:u=!1,rippleX:N,rippleY:r,rippleSize:f,in:L,onExited:m,timeout:n}=s,[h,y]=ee.useState(!1),d=a(x,l.ripple,l.rippleVisible,u&&l.ripplePulsate),E={width:f,height:f,top:-(f/2)+r,left:-(f/2)+N},i=a(l.child,h&&l.childLeaving,u&&l.childPulsate);return!L&&!h&&y(!0),ee.useEffect(()=>{if(!L&&m!=null){let T=setTimeout(m,n);return()=>{clearTimeout(T)}}},[m,L,n]),(0,le.jsx)("span",{className:d,style:E,children:(0,le.jsx)("span",{className:i})})}var Re=We;var Ge=J("MuiTouchRipple",["root","ripple","rippleVisible","ripplePulsate","child","childLeaving","childPulsate"]),c=Ge;var oe=_(G()),Je=["center","classes","className"],te=s=>s,be,Pe,ge,xe,ae=550,Qe=80,Ze=(0,Q.keyframes)(be||(be=te`
  0% {
    transform: scale(0);
    opacity: 0.1;
  }

  100% {
    transform: scale(1);
    opacity: 0.3;
  }
`)),eo=(0,Q.keyframes)(Pe||(Pe=te`
  0% {
    opacity: 1;
  }

  100% {
    opacity: 0;
  }
`)),oo=(0,Q.keyframes)(ge||(ge=te`
  0% {
    transform: scale(1);
  }

  50% {
    transform: scale(0.92);
  }

  100% {
    transform: scale(1);
  }
`)),to=Y("span",{name:"MuiTouchRipple",slot:"Root"})({overflow:"hidden",pointerEvents:"none",position:"absolute",zIndex:0,top:0,right:0,bottom:0,left:0,borderRadius:"inherit"}),so=Y(Re,{name:"MuiTouchRipple",slot:"Ripple"})(xe||(xe=te`
  opacity: 0;
  position: absolute;

  &.${0} {
    opacity: 0.3;
    transform: scale(1);
    animation-name: ${0};
    animation-duration: ${0}ms;
    animation-timing-function: ${0};
  }

  &.${0} {
    animation-duration: ${0}ms;
  }

  & .${0} {
    opacity: 1;
    display: block;
    width: 100%;
    height: 100%;
    border-radius: 50%;
    background-color: currentColor;
  }

  & .${0} {
    opacity: 0;
    animation-name: ${0};
    animation-duration: ${0}ms;
    animation-timing-function: ${0};
  }

  & .${0} {
    position: absolute;
    /* @noflip */
    left: 0px;
    top: 0;
    animation-name: ${0};
    animation-duration: 2500ms;
    animation-timing-function: ${0};
    animation-iteration-count: infinite;
    animation-delay: 200ms;
  }
`),c.rippleVisible,Ze,ae,({theme:s})=>s.transitions.easing.easeInOut,c.ripplePulsate,({theme:s})=>s.transitions.duration.shorter,c.child,c.childLeaving,eo,ae,({theme:s})=>s.transitions.easing.easeInOut,c.childPulsate,oo,({theme:s})=>s.transitions.easing.easeInOut),ro=t.forwardRef(function(x,l){let u=Z({props:x,name:"MuiTouchRipple"}),{center:N=!1,classes:r={},className:f}=u,L=W(u,Je),[m,n]=t.useState([]),h=t.useRef(0),y=t.useRef(null);t.useEffect(()=>{y.current&&(y.current(),y.current=null)},[m]);let d=t.useRef(!1),E=t.useRef(null),i=t.useRef(null),T=t.useRef(null);t.useEffect(()=>()=>{clearTimeout(E.current)},[]);let K=t.useCallback(o=>{let{pulsate:R,rippleX:b,rippleY:w,rippleSize:$,cb:z}=o;n(P=>[...P,(0,oe.jsx)(so,{classes:{ripple:a(r.ripple,c.ripple),rippleVisible:a(r.rippleVisible,c.rippleVisible),ripplePulsate:a(r.ripplePulsate,c.ripplePulsate),child:a(r.child,c.child),childLeaving:a(r.childLeaving,c.childLeaving),childPulsate:a(r.childPulsate,c.childPulsate)},timeout:ae,pulsate:R,rippleX:b,rippleY:w,rippleSize:$},h.current)]),h.current+=1,y.current=z},[r]),j=t.useCallback((o={},R={},b=()=>{})=>{let{pulsate:w=!1,center:$=N||R.pulsate,fakeElement:z=!1}=R;if((o==null?void 0:o.type)==="mousedown"&&d.current){d.current=!1;return}(o==null?void 0:o.type)==="touchstart"&&(d.current=!0);let P=z?null:T.current,k=P?P.getBoundingClientRect():{width:0,height:0,left:0,top:0},C,V,D;if($||o===void 0||o.clientX===0&&o.clientY===0||!o.clientX&&!o.touches)C=Math.round(k.width/2),V=Math.round(k.height/2);else{let{clientX:S,clientY:M}=o.touches&&o.touches.length>0?o.touches[0]:o;C=Math.round(S-k.left),V=Math.round(M-k.top)}if($)D=Math.sqrt((2*k.width**2+k.height**2)/3),D%2===0&&(D+=1);else{let S=Math.max(Math.abs((P?P.clientWidth:0)-C),C)*2+2,M=Math.max(Math.abs((P?P.clientHeight:0)-V),V)*2+2;D=Math.sqrt(S**2+M**2)}o!=null&&o.touches?i.current===null&&(i.current=()=>{K({pulsate:w,rippleX:C,rippleY:V,rippleSize:D,cb:b})},E.current=setTimeout(()=>{i.current&&(i.current(),i.current=null)},Qe)):K({pulsate:w,rippleX:C,rippleY:V,rippleSize:D,cb:b})},[N,K]),O=t.useCallback(()=>{j({},{pulsate:!0})},[j]),I=t.useCallback((o,R)=>{if(clearTimeout(E.current),(o==null?void 0:o.type)==="touchend"&&i.current){i.current(),i.current=null,E.current=setTimeout(()=>{I(o,R)});return}i.current=null,n(b=>b.length>0?b.slice(1):b),y.current=R},[]);return t.useImperativeHandle(l,()=>({pulsate:O,start:j,stop:I}),[O,j,I]),(0,oe.jsx)(to,F({className:a(c.root,r.root,f),ref:T},L,{children:(0,oe.jsx)(ye,{component:null,exit:!0,children:m})}))}),Ce=ro;function Me(s){return he("MuiButtonBase",s)}var no=J("MuiButtonBase",["root","disabled","focusVisible"]),Be=no;var Ne=_(G()),Ee=_(G()),io=["action","centerRipple","children","className","component","disabled","disableRipple","disableTouchRipple","focusRipple","focusVisibleClassName","LinkComponent","onBlur","onClick","onContextMenu","onDragLeave","onFocus","onFocusVisible","onKeyDown","onKeyUp","onMouseDown","onMouseLeave","onMouseUp","onTouchEnd","onTouchMove","onTouchStart","tabIndex","TouchRippleProps","touchRippleRef","type"],po=s=>{let{disabled:x,focusVisible:l,focusVisibleClassName:u,classes:N}=s,f=de({root:["root",x&&"disabled",l&&"focusVisible"]},Me,N);return l&&u&&(f.root+=` ${u}`),f},lo=Y("button",{name:"MuiButtonBase",slot:"Root",overridesResolver:(s,x)=>x.root})({display:"inline-flex",alignItems:"center",justifyContent:"center",position:"relative",boxSizing:"border-box",WebkitTapHighlightColor:"transparent",backgroundColor:"transparent",outline:0,border:0,margin:0,borderRadius:0,padding:0,cursor:"pointer",userSelect:"none",verticalAlign:"middle",MozAppearance:"none",WebkitAppearance:"none",textDecoration:"none",color:"inherit","&::-moz-focus-inner":{borderStyle:"none"},[`&.${Be.disabled}`]:{pointerEvents:"none",cursor:"default"},"@media print":{colorAdjust:"exact"}}),ao=p.forwardRef(function(x,l){let u=Z({props:x,name:"MuiButtonBase"}),{action:N,centerRipple:r=!1,children:f,className:L,component:m="button",disabled:n=!1,disableRipple:h=!1,disableTouchRipple:y=!1,focusRipple:d=!1,LinkComponent:E="a",onBlur:i,onClick:T,onContextMenu:K,onDragLeave:j,onFocus:O,onFocusVisible:I,onKeyDown:o,onKeyUp:R,onMouseDown:b,onMouseLeave:w,onMouseUp:$,onTouchEnd:z,onTouchMove:P,onTouchStart:k,tabIndex:C=0,TouchRippleProps:V,touchRippleRef:D,type:S}=u,M=W(u,io),A=p.useRef(null),g=p.useRef(null),ke=pe(g,D),{isFocusVisibleRef:ce,onFocus:Ve,onBlur:De,ref:Le}=Te(),[U,v]=p.useState(!1);n&&U&&v(!1),p.useImperativeHandle(N,()=>({focusVisible:()=>{v(!0),A.current.focus()}}),[]);let[se,we]=p.useState(!1);p.useEffect(()=>{we(!0)},[]);let Se=se&&!h&&!n;p.useEffect(()=>{U&&d&&!h&&se&&g.current.pulsate()},[h,d,U,se]);function B(e,fe,He=y){return q(me=>(fe&&fe(me),!He&&g.current&&g.current[e](me),!0))}let Ue=B("start",b),_e=B("stop",K),je=B("stop",j),Ie=B("stop",$),$e=B("stop",e=>{U&&e.preventDefault(),w&&w(e)}),Fe=B("start",k),Ke=B("stop",z),Oe=B("stop",P),ze=B("stop",e=>{De(e),ce.current===!1&&v(!1),i&&i(e)},!1),Ae=q(e=>{A.current||(A.current=e.currentTarget),Ve(e),ce.current===!0&&(v(!0),I&&I(e)),O&&O(e)}),re=()=>{let e=A.current;return m&&m!=="button"&&!(e.tagName==="A"&&e.href)},ne=p.useRef(!1),Xe=q(e=>{d&&!ne.current&&U&&g.current&&e.key===" "&&(ne.current=!0,g.current.stop(e,()=>{g.current.start(e)})),e.target===e.currentTarget&&re()&&e.key===" "&&e.preventDefault(),o&&o(e),e.target===e.currentTarget&&re()&&e.key==="Enter"&&!n&&(e.preventDefault(),T&&T(e))}),Ye=q(e=>{d&&e.key===" "&&g.current&&U&&!e.defaultPrevented&&(ne.current=!1,g.current.stop(e,()=>{g.current.pulsate(e)})),R&&R(e),T&&e.target===e.currentTarget&&re()&&e.key===" "&&!e.defaultPrevented&&T(e)}),H=m;H==="button"&&(M.href||M.to)&&(H=E);let X={};H==="button"?(X.type=S===void 0?"button":S,X.disabled=n):(!M.href&&!M.to&&(X.role="button"),n&&(X["aria-disabled"]=n));let qe=pe(l,Le,A),ue=F({},u,{centerRipple:r,component:m,disabled:n,disableRipple:h,disableTouchRipple:y,focusRipple:d,tabIndex:C,focusVisible:U}),ve=po(ue);return(0,Ee.jsxs)(lo,F({as:H,className:a(ve.root,L),ownerState:ue,onBlur:ze,onClick:T,onContextMenu:_e,onFocus:Ae,onKeyDown:Xe,onKeyUp:Ye,onMouseDown:Ue,onMouseLeave:$e,onMouseUp:Ie,onDragLeave:je,onTouchEnd:Ke,onTouchMove:Oe,onTouchStart:Fe,ref:qe,tabIndex:n?-1:C,type:S},X,M,{children:[f,Se?(0,Ne.jsx)(Ce,F({ref:ke,center:r},V)):null]}))}),co=ao;export{co as a};
