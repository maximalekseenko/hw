#pragma once

#include "tree.h"



template <class T_Node>
class TreeAVLBase : public TreeBase<T_Node> {
    public:
        using TreeBase<T_Node>::TreeBase;
        using TreeBase<T_Node>::__get_arm_left;
        using TreeBase<T_Node>::__get_arm_right;
        using TreeBase<T_Node>::__get_parent;
        using TreeBase<T_Node>::__get_value;

        using TreeBase<T_Node>::__this_as_t_node;
        using TreeBase<T_Node>::__is_root;
        using TreeBase<T_Node>::__is_leaf;
        using TreeBase<T_Node>::__is_arm_left;
        using TreeBase<T_Node>::__is_arm_left_exists;
        using TreeBase<T_Node>::__is_arm_right;
        using TreeBase<T_Node>::__is_arm_right_exists;
        using TreeBase<T_Node>::__is_parent;
        using TreeBase<T_Node>::__is_parent_exists;
        using TreeBase<T_Node>::__is_arm;
        using TreeBase<T_Node>::__is_arm_any_exists;
        using TreeBase<T_Node>::__is_arm_all_exists;
        using TreeBase<T_Node>::__is_value_left;
        using TreeBase<T_Node>::__is_value_right;
        using TreeBase<T_Node>::__is_value_this;
        using TreeBase<T_Node>::__set_parent;

        using TreeBase<T_Node>::AddNode;
        using TreeBase<T_Node>::PrintTree;
        using TreeBase<T_Node>::DepthTree;
        using TreeBase<T_Node>::SearchNode;
        using TreeBase<T_Node>::DelTree;
        using TreeBase<T_Node>::DelNode;
        using TreeBase<T_Node>::GetFullString;
        using TreeBase<T_Node>::Update;
        using TreeBase<T_Node>::ToString;

    protected:

        bool __is_balanced() {
            return __get_balance() < 2;
        }

        int __get_balance() {
            return abs(
                (__is_arm_left_exists() ? __get_arm_left()->DepthTree() : 0)
                - 
                (__is_arm_right_exists() ? __get_arm_right()->DepthTree() : 0)
            );
        }

        bool __is_left_unbalanced() {
            return  DepthTree(__get_arm_left()) - DepthTree(__get_arm_right()) > 1;
        }
        bool __is_right_unbalanced() {
            return  DepthTree(__get_arm_left()) - DepthTree(__get_arm_right()) < -1;
        }

        void __rotation_small_left() {
            T_Node* __b_arm = __get_arm_right();
            __b_arm->__set_parent(__get_parent());

            if (__b_arm->__is_arm_left_exists())
                __b_arm->__get_arm_left()->__set_parent(__this_as_t_node());

            __set_parent(__b_arm);
        }

        void __rotation_small_right() {
            T_Node* __b_arm = __get_arm_left();
            __b_arm->__set_parent(__get_parent());

            if (__b_arm->__is_arm_right_exists())
                __b_arm->__get_arm_right()->__set_parent(__this_as_t_node());

            __set_parent(__b_arm);
        }

        void __rotation_big_left() {
            T_Node* __b_arm = __get_arm_right();
            T_Node* __c_arm = __b_arm->__get_arm_left();
            __c_arm->__set_parent(__get_parent());

            if (__c_arm->__is_arm_left_exists())
                __c_arm->__get_arm_left()->__set_parent(__this_as_t_node());
            if (__c_arm->__is_arm_right_exists())
                __c_arm->__get_arm_right()->__set_parent(__b_arm);
                
            __b_arm->__set_parent(__c_arm);
            __set_parent(__c_arm);
        }

        void __rotation_big_right() {
            T_Node* __b_arm = __get_arm_left();
            T_Node* __c_arm = __b_arm->__get_arm_right();
            __c_arm->__set_parent(__get_parent());

            if (__c_arm->__is_arm_left_exists())
                __c_arm->__get_arm_left()->__set_parent(__b_arm);
            if (__c_arm->__is_arm_right_exists())
                __c_arm->__get_arm_right()->__set_parent(__this_as_t_node());

            __b_arm->__set_parent(__c_arm);
            __set_parent(__c_arm);
        }

        void __balance_back() {
            if (!__is_balanced()){
                if (__is_left_unbalanced()){
                    if (__get_arm_left()->__is_left_unbalanced()) 
                        __rotation_small_right();
                    else if (__get_arm_left()->__is_right_unbalanced())
                        __rotation_big_right();
                }
                else if (__is_right_unbalanced()){
                    if (__get_arm_right()->__is_right_unbalanced())
                        __rotation_small_left();
                    else if (__get_arm_right()->__is_left_unbalanced())
                        __rotation_big_left();
                }
            } 

            if (!__is_root()) __get_parent()->__balance_back();
        }
    
    public:

        void AddNode(int __value) {
            TreeBase<T_Node>::AddNode(__value);

            __balance_back();   
        }

        void DelNode() {
            T_Node* __hash_parent = __get_parent();
            TreeBase<T_Node>::DelNode();
            __hash_parent->__balance_back();
        }

        std::string ToString() { return std::to_string(__get_value()) + " - " + std::to_string(__get_balance()); }

}; class TreeAVL : public TreeAVLBase<TreeAVL> { using TreeAVLBase::TreeAVLBase; };
