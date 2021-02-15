# NanoFSM
A highly compact and light-weight general purpose finite state machine.

## Two Flavors
NanoFSM comes in two flavors. <i>Basic</i> and <i>Minimal</i>. The basic implementation
offers both safety and performance while the minimal implementation reduces LoC at the
expense of both safety and performance. However, both implementations follow the same
set of rules:

#### 1. States are responsible for deciding the next transition.
The state machine manager should never be responsible for deciding which state it should
trasition to. This removes the need for switches and enumerations. The only added exception
is mentioned in rule #3.

#### 2. State machine manager is responsible for making transitions.
States themselves shoud never be allowed to make transitions directly. Instead, states are
to request which states they would like to transition to. This ensures that control is
always tranferred back to the state machine manager, thus for, relieving pressure on the call
stack.

#### 3. State machine manager is responsible for state machine shutdown.
States themselves should never be allowed to shutdown the state machine. If there is no state
for a state to transition to then that state should return a null value. The state machine
manager will then be responsible for deciding if the state machine should shutdown, restart,
or transition to a fallback/error state.

Adhering to these rules will ensure high scalability and maintainability across all of your
models. Additionally, with some ingenuity, this can also be used for deep recursion and will
never flood the call stack.
